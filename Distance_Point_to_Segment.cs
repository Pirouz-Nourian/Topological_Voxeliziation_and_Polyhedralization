public double Dist_Point_Segment(Point3d P, Line S)
  {
    Point3d P0 = S.From;
    //start point of segemnt
    Point3d P1 = S.To;
    //end poiunt of segment
    Vector3d V = S.To - P0;
    //EndPoint-StartPoint
    Vector3d W = P - P0;
    //the vector from point to start of the segment
    double c1 = W * V;
    // * is used for dot product
    if (c1 <= 0)
      return P.DistanceTo(P0);
    //Eucleadian distance of the point to the start of the line
    double c2 = V * V;
    if (c2 <= c1)
      return P.DistanceTo(P1);
    //Eucleadian distance of the point to the end of the line
    double b = c1 / c2;
    Point3d Pb = P0 + b * V;
    //point on the line segment closest to P
    return P.DistanceTo(Pb);
  }
