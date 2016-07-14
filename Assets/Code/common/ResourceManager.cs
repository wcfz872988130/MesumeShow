using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager{
    public static GameObject _bg;
    public static GameObject _chooseResource;
    public static int _guliCount = 0;
	public static int _treeCount=0;
	public static bool _KillHorse=false;
	public static bool _hasBuilt=false;
    public static int HiStage = 0;
	public static int Score=30;
	public static List<string> _totalEquipement=new List<string>();

	public static string nextScene="";

	//lz
	public static int _shiCount = 0;

	public static int _knowligen = 0;   //是否会李根叔

	public static int _knowzhitaoshu = 0;//是否会制陶术

	public static int _knowfuhaoshu = 0;
}
