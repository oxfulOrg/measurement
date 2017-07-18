using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace enviriomentMeasurement
{
    /*
     * 测量工程
     */
    struct measuring_project
    {
        public int id;
        public string name;
    }

    /*
     * 测量对象
     */
    struct measuring_classify
    {
        public int id;
        public string name;
        public int pro_id;
    }

    /*
     * 测量物
     */
    struct measuring_object
    {
        public int id;
        public string name;
        public int classify_id;
    }

    /*
     * 测量结果分类
     */
    struct measuring_outcome_define
    {
        public int id;
        public double max;
        public double min;
        public string name;
        public int obj_id;
        public int operator_id;
        public int unit_id;
    }

    /*
     * 测量工具
     */
    struct measuring_tool
    {
        public int id;
        public double capaciy;
        public int method_id;
        public string name;
        public int unit_id;
    }

    /*
     * 测量方法
     */
    struct measuring_method
    {
        public int id;
        public string name;
        public int obj_id;
    }

    /**
     * 测量条件
     */
    struct measuring_environment
    {
        public int id;
        public string name;
        public int obj_id;
    }




    class dataStruct
    {
        int id;
        string name;

        public List<measuring_project> projectList;
        public List<measuring_classify> classList;
        public List<measuring_outcome_define> outcomeDefine;
        public List<measuring_object> objList;
        public List<measuring_method> methodList;
        public List<measuring_environment> envList;
        public List<measuring_tool> toolsList;


        public Dictionary<int, List<measuring_classify>> mapProject2Class;

        public Dictionary<int, List<measuring_outcome_define>> mapProject2OutcomeDefine;

        public Dictionary<int, List<measuring_object>> mapClass2Obj;

        public Dictionary<int, List<measuring_method>> mapObj2Method;

        public Dictionary<int, List<measuring_tool>> mapMethod2Tools;

        public Dictionary<int, List<measuring_environment>> mapObj2Enviroment;

        public dataStruct()
        {
            projectList = new List<measuring_project>();
            classList = new List<measuring_classify>();
            outcomeDefine = new List<measuring_outcome_define>();
            objList = new List<measuring_object>();
            methodList = new List<measuring_method>();
            envList = new List<measuring_environment>();
            toolsList = new List<measuring_tool>();

            mapProject2Class = new Dictionary<int, List<measuring_classify>>();
            mapProject2OutcomeDefine = new Dictionary<int, List<measuring_outcome_define>>();
            mapClass2Obj = new Dictionary<int, List<measuring_object>>();
            mapObj2Method = new Dictionary<int, List<measuring_method>>();
            mapMethod2Tools = new Dictionary<int, List<measuring_tool>>();
            mapObj2Enviroment = new Dictionary<int, List<measuring_environment>>();
        }

        public List<measuring_classify> getClassFromProject(int id)
        {
            if (mapProject2Class.ContainsKey(id))
                return mapProject2Class[id];
            return null;
        }

        public void addProject(ref measuring_project data)
        {
            projectList.Add(data);
        }

        public void updateProject(DataView view)
        {
            //TODO:projectList
            measuring_project tmp;

            foreach (DataRow row in view.Table.Rows)
            {
                tmp.id = int.Parse(row[0].ToString());
                tmp.name = row[1].ToString();
                projectList.Add(tmp);
            }
        }


        public void addClass(ref measuring_classify data, ref int id)
        {
            classList.Add(data);
            if(mapProject2Class.ContainsKey(id))
            {
                mapProject2Class[id].Add(data);
                return;
            }
            List<measuring_classify> list = new List<measuring_classify>();
            list.Add(data);
            mapProject2Class.Add(id, list);
        }

        public void delClass(int id)
        {
            //删除classlist
            foreach(measuring_classify data in classList)
            {
                if(data.id == id)
                {
                    classList.Remove(data);
                }
            }
            
            //TODO 删除所有数据
		}

        public void updateClass(DataView view)
        {
            //TODO:classList
            measuring_classify mcy;

            //TODO:mapProject2Class
            /*foreach (DataRow row in view.Table.Rows)
            {
                mcy.id = int.Parse(row[0].ToString());
                mcy.name = row[1].ToString();
                mcy.pro_id = int.Parse(row[2].ToString());
                classList.Add(mcy);
            }*/
        }


        public void addoutcomeDefine(ref measuring_outcome_define data, ref int id)
        {
            //TODO:outcomeDefine
            outcomeDefine.Add(data);
            if (mapProject2OutcomeDefine.ContainsKey(id))
            {
                mapProject2OutcomeDefine[id].Add(data);
                return;
            }

            //TODO:mapProject2OutcomeDefine
            List<measuring_outcome_define> list = new List<measuring_outcome_define>();
            list.Add(data);
            mapProject2OutcomeDefine.Add(id, list);

        }

        public void updateoutcomeDefine(DataView view)
        {
            //TODO:outcomeDefine
            measuring_outcome_define mod;

            //TODO:mapProject2OutcomeDefine
            /*foreach (DataRow row in view.Table.Rows)
            {
                mod.id = int.Parse(row[0].ToString());
                mod.max = double.Parse(row[1].ToString());
                mod.min = double.Parse(row[2].ToString());
                mod.name = row[3].ToString();
                mod.obj_id = int.Parse(row[4].ToString());
                mod.operator_id = int.Parse(row[5].ToString());
                mod.unit_id = int.Parse(row[6].ToString());
                outcomeDefine.Add(mod);
            }*/

        }

        public void addObj(ref measuring_object data, ref int id)
        {
            //TODO:objList
            objList.Add(data);
            if (mapProject2OutcomeDefine.ContainsKey(id))
            {
                mapClass2Obj[id].Add(data);
                return;
            }

            //TODO:mapClass2Obj
            List<measuring_object> list = new List<measuring_object>();
            list.Add(data);
            mapClass2Obj.Add(id, list);
        }

        public void updateObj(DataView view)
        {
            //TODO:objList
            measuring_object mot;

            //TODO:mapClass2Obj
            /*foreach (DataRow row in view.Table.Rows)
            {
                mot.id = int.Parse(row[0].ToString());
                mot.name = row[1].ToString();
                mot.classify_id = int.Parse(row[2].ToString());
                objList.Add(mot);
            }*/
        }

        public void addEnv(ref measuring_environment data, ref int id)
        {
            //TODO:envList
            envList.Add(data);
            if (mapObj2Enviroment.ContainsKey(id))
            {
                mapObj2Enviroment[id].Add(data);
                return;
            }
            
            //TODO:mapObj2Enviroment
            List<measuring_environment> list = new List<measuring_environment>();
            list.Add(data);
            mapObj2Enviroment.Add(id, list);
        }

        public void updateEnv(DataView view)
        {
            //TODO:envList
            measuring_environment met;

            //TODO:mapObj2Enviroment
            /*foreach (DataRow row in view.Table.Rows)
            {
                met.id = int.Parse(row[0].ToString());
                met.name = row[1].ToString();
                met.obj_id = int.Parse(row[2].ToString());
                envList.Add(met);
            }*/
        }

        public void addTools(ref measuring_tool data, ref int id)
        {
            //TODO:toolsList
            toolsList.Add(data);
            if (mapMethod2Tools.ContainsKey(id))
            {
                mapMethod2Tools[id].Add(data);
                return;
            }

            //TODO:mapMethod2Tools
            List<measuring_tool> list = new List<measuring_tool>();
            list.Add(data);
            mapMethod2Tools.Add(id, list);
        }

        public void updateTools(DataView view)
        {
            //TODO:toolsList
            measuring_tool mtl;

            //TODO:mapMethod2Tools
            /*foreach (DataRow row in view.Table.Rows)
            {
                mtl.id = int.Parse(row[0].ToString());
                mtl.capaciy = double.Parse(row[1].ToString());
                mtl.method_id = int.Parse(row[2].ToString());
                mtl.name = row[3].ToString();
                mtl.unit_id = int.Parse(row[4].ToString());
                toolsList.Add(mtl);
            }*/
        }

        public void addMethod(ref measuring_method data, ref int id)
        {
            //TODO:methodList
            methodList.Add(data);
            if (mapObj2Method.ContainsKey(id))
            {
                mapObj2Method[id].Add(data);
                return;
            }

            //TODO:mapObj2Method
            List<measuring_method> list = new List<measuring_method>();
            list.Add(data);
            mapObj2Method.Add(id, list);
        }

        public void updateMethod(DataView view)
        {
            //TODO:methodList
            measuring_method mmd;

            //TODO:mapObj2Method
            /*foreach (DataRow row in view.Table.Rows)
            {
                mmd.id = int.Parse(row[0].ToString());
                mmd.name = row[1].ToString();
                mmd.obj_id = int.Parse(row[2].ToString());
                methodList.Add(mmd);
            }*/
        }
        
    }
}
