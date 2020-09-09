"""Provides a scripting component.
    Inputs:
        x: The x script variable
        y: The y script variable
    Output:
        a: The a output variable"""

__author__ = "pnourian"
__version__ = "2020.08.23"

import Rhino.Geometry as rg
blockMeshes=[]
for blockMesh in B:
    edgeLines=[blockMesh.TopologyEdges.EdgeLine(i) for i in range(blockMesh.TopologyEdges.Count)]
    doesIntersect=False
    for edgeLine in edgeLines:
        if rg.Intersect.Intersection.MeshLine(M,edgeLine)[1]!=None:
            doesIntersect=True
            break
    if doesIntersect:
        blockMeshes.append(blockMesh)
Blocks=blockMeshes
