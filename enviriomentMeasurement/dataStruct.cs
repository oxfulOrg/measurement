using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace enviriomentMeasurement
{

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
            //TODO:mapProject2Class
        }


        public void addoutcomeDefine(ref measuring_classify data, ref int id)
        {
            //TODO:outcomeDefine
            //TODO:mapProject2OutcomeDefine
        }

        public void updateoutcomeDefine(DataView view)
        {
            //TODO:outcomeDefine
            //TODO:mapProject2OutcomeDefine

        }

        public void addObj(DataView view)
        {
            //TODO:objList
            //TODO:mapClass2Obj
        }

        public void updateObj(DataView view)
        {
            //TODO:objList
            //TODO:mapClass2Obj
        }

        public void addEnv(DataView view)
        {
            //TODO:envList
            //TODO:mapObj2Enviroment
        }

        public void updateEnv(DataView view)
        {
            //TODO:envList
            //TODO:mapObj2Enviroment
        }

        public void addTools(DataView view)
        {
            //TODO:toolsList
            //TODO:mapMethod2Tools
        }

        public void updateTools(DataView view)
        {
            //TODO:toolsList
            //TODO:mapMethod2Tools
        }

        public void addMethod(DataView view)
        {
            //TODO:methodList
            //TODO:mapObj2Method
        }

        public void updateMethod(DataView view)
        {
            //TODO:methodList
            //TODO:mapObj2Method
        }
        
    }
}
