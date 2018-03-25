public double Dist_point_Triangle(Point3d[] Vx, Point3d P)
  {
    Point3d O = Vx[0];
    Vector3d U = Vx[1] - O;
    Vector3d V = Vx[2] - O;

    Vector3d W = P - O;

    double UU = U * U;
    double VV = V * V;
    double UV = U * V;
    double WU = W * U;
    double WV = W * V;

    double det = Math.Abs(Math.Pow(UV, 2) - UU * VV);
    // determinant will be >0 only if the two edges are not colinear (i.e. the triangle is NOT degenerate)
    if (det > 0) {
      double s = -(UV * WV - VV * WU);
      /// det
      double t = -(UV * WU - UU * WV);
      /// det

      //left half of the line(V1,V2)
      if (s + t <= det) {
        if (s < 0) {
          if (t < 0) {
            //Region4, distance to V0
            return Vx[0].DistanceTo(P);            //P.DistanceTo(Vx(0))
          } else {
            //Region3, distance to line(V0,V2)

            return Dist_Point_Segment(P, new Line(Vx[0], Vx[2]));
          }
        } else if (t < 0) {
          //Region5, distance to line(V0,V1)

          return Dist_Point_Segment(P, new Line(Vx[0], Vx[1]));
        } else {
          //Region0, distance to point(s,t)

          s = s / det;
          t = t / det;
          Point3d Vertex = O + s * U + t * V;
          return Vertex.DistanceTo(P);

        }
        // right half of the line(V1,V2)
      } else {
        if (s < 0) {
          //Region2, distance to V2

          return Vx[2].DistanceTo(P);
          //P.DistanceTo(Vx(2))
        } else if (t < 0) {
          //Region6, distance to V1

          return Vx[1].DistanceTo(P);
          //P.DistanceTo(Vx(1))
        } else {
          //Region1, distance to line(V1,V2)

          return Dist_Point_Segment(P, new Line(Vx[1], Vx[2]));
        }
      }
    } else {
      return -1;//det=0, the triangle is degenerate!!!
      throw new Exception("there is a degenerate triangle!");
    }
  }
