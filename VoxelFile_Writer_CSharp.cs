@@ -0,0 +1,32 @@
private void RunScript(int CO, List<Mesh> ObjM, List<Color> ObjC, string FPath, double Sx, double Sy, double Sz, ref object A)
  {
    List<Mesh> Meshes = ObjM;
    List<Color> Colors = ObjC;

    Vector3d VSize = new Vector3d(Sx, Sy, Sz);

    double Distance = VSize.Length / 2;

    List<Tuple<int, double, double, double, byte, byte, byte>> VT = new List<Tuple<int, double, double, double, byte, byte, byte>>();
    //Voxel Tuples'List(Of String())'
    PointCloud VPC = new PointCloud();
    //VoxelPointCloud
    for (int i = 0; i <= ObjM.Count - 1; i++) {
      VT.AddRange(VoxelizeMesh(Meshes[i], Colors[i], i, VSize, CO, ref VPC));
    }

    System.IO.StreamWriter SW = File.CreateText(FPath);
    string result = "";
    //k As Integer=0 To VT.count - 1'String() In VT'
    foreach (Tuple<int, double, double, double, byte, byte, byte> vtp in VT) {
      result = vtp.Item1 + "," + vtp.Item2 + "," + vtp.Item3 + "," + vtp.Item4 + "," + vtp.Item5 + "," + vtp.Item6 + "," + vtp.Item7;
      //String.Join(",", vtp) 'vtp.toString'
      SW.WriteLine(result);
    }
    SW.Close();

    PCloud = null;
    PCloud = VPC;

  }
