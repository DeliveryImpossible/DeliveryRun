using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapName
{
    public static string GetMapName(int mapNum)
    {
        switch (mapNum)
        {
            case 1:
                return "혼돈의 도시";
            case 2:
                return "평화로운 시골 마을";
            case 3:
                return "지옥에서 온 던전";
            default:
                return "잘못된 번호";
    }
}
}
