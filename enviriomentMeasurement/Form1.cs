using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enviriomentMeasurement
{
    public partial class Form1 : Form
    {
        sqlEngin sqleng = new sqlEngin();
        dataStruct allData = new dataStruct();

        addClassify addClassForm = new addClassify();
        //addClassForm.CloseFrm += new EventHandler(frmA_CloseFrm);

        int curProject;
        int curClass;
        int curObj;
        int curMethod;
        int curEvn;
        int curTools;
        int curOutCome;

        struct ID_NAME
        {
            public int id;
            public string name;
        }

        Dictionary<int, string> mapClass;
        Dictionary<int, string> mapObj;
        Dictionary<int, string> mapMethod;
        Dictionary<int, string> mapEvn;
        Dictionary<int, string> mapTools;
        Dictionary<int, string> mapOutcome;

        public Form1()
        {

            InitializeComponent();
            getAllProjectDataFromDB();

            disabelAllCtrls();

            addClassForm.addData += new EventHandler(addClassForm_add);

            foreach (Control ctl in this.Controls)
            {
                if ((ctl as RadioButton) != null)
                {
                    ((RadioButton)ctl).CheckedChanged += new System.EventHandler(radio_select);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void radio_select(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //把之前选中的radio的  子项的所有信息都关闭


                //显示新选中的 关联的子项信息
                //从alldata 里面把子项数据找出来
                //
            }
            //else
            //{
            //    //把他子项的所有信息都关闭

            //}
        }
        

        public void addClassForm_add(object sender, EventArgs e)
        {
            //addClassForm.getData
            string name = addClassForm.getData();
            int id = 65535;
            //add db and alldata
            if (name != "")
            {

                id = addClass(name, curProject);
            
            }
            //更新控件显示
            if (id != 65535)
            {
                addNewRadioInGroup(this.groupClass, id, name);
            }
        }


        /**
         * 新增一个project
         */
        private int addProject(string name)
        {

            try
            {
                //添加数据库数据
                string sql = "insert into measuring_project(name) values('" + name + "')";
                int ret = sqleng.MysqlCommand(sql);
                sql = "select * from measuring_project where Id in( select max(Id) from measuring_project)";
                DataView view = sqleng.ExecuteDataView(sql);

                measuring_project pro;

                pro.id = int.Parse(view.Table.Rows[0][0].ToString());//.Field<int>(new DataColumn("Id"));
                pro.name = view.Table.Rows[0][1].ToString();//.Field<string>(new DataColumn("name"));
                                                            //添加alldata 数据
                allData.addProject(ref pro);

                return pro.id;
            }
            catch(Exception ex)
            {
                return -1;
            }

        }
        
        private void updateProject()
        {
            //TODO 构造sql 语句
            string sql = "select * from measuring_project";
            allData.updateProject(sqleng.ExecuteDataView(sql));
        }

        /// <summary>
        /// 添加class 测量对象数据到数据库和 alldata 同时返回当前的class id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="project_id"></param>
        /// <returns></returns>
        private int addClass(string name, int project_id)
        {
            //TODO 构造sql 语句 添加数据库数据
            //string sql = "insert into measuring_project(name) values(" + name + ")";

            //添加alldata 数据
            return 0;
        }

        private void updateClass()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateClass(sqleng.ExecuteDataView(sql));
        }

        private void updateoutcomeDefine()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateoutcomeDefine(sqleng.ExecuteDataView(sql));
        }

        private void updateObj()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateObj(sqleng.ExecuteDataView(sql));
        }

        private void updateEnv()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateEnv(sqleng.ExecuteDataView(sql));
        }

        private void updateTools()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateTools(sqleng.ExecuteDataView(sql));
        }

        private void updateMethod()
        {
            //TODO 构造sql 语句
            string sql = "";
            allData.updateMethod(sqleng.ExecuteDataView(sql));
        }

        void updatecomboBox1()
        {
            foreach(measuring_project pro in allData.projectList)
            {
                object obj = new object();
                obj = (object)(pro.id.ToString() + "_" + pro.name);
                this.comboBox1.Items.Add(obj);
            }
        }


        private void getAllProjectDataFromDB()
        {
            //get all project name from DB ...            
            updateProject();
            updateClass();
            updateObj();
            updateEnv();
            updateMethod();            
            updateoutcomeDefine();
            updateTools();

            //更新头部的下拉项目菜单
            updatecomboBox1();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.projectText.Text == "")
            {
                MessageBox.Show("请输入项目名称");
                return;
            }

            //添加数据
            curProject = addProject(projectText.Text);

            if (-1 == curProject)
            {
                MessageBox.Show("已存在");
                return;
            }

            //删除所有控件信息
            disabelAllCtrls();

            //构造数据
            List<ID_NAME> lst = new List<ID_NAME>();
            ID_NAME data = new ID_NAME();

            List<measuring_classify> tmp = allData.getClassFromProject(curProject);

            //这里肯定是null 但是为了其他地方做个参考使用
            if (null != tmp)
            {
                foreach(measuring_classify cls in tmp)
                {
                    data.id = cls.id;
                    data.name = cls.name;
                    lst.Add(data);
                }
                
            }
            //更新控件显示
            updateCtrlVisable(this.groupClass, true, ref lst);

        }

#region ctrl display
        /// <summary>
        /// 去掉所有group 显示
        /// </summary>
        private void disabelAllCtrls()
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.Visible = true;
                if ((ctl as GroupBox) != null)
                {
                    foreach (Control c in ctl.Controls)
                    {
                        c.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 去掉group下所有控件显示
        /// </summary>
        /// <param name="ctrl"></param>
        private void disabelOneGroup(Control ctrl)
        {
            if ((ctrl as GroupBox) != null)
            {
                foreach (Control c in ctrl.Controls)
                {
                    c.Visible = false;
                }
            }
        }

       /// <summary>
       /// 更新某些控件显示
       /// </summary>
       /// <param name="ctrls"></param>
       /// <param name="flag"></param>
        private void updateCtrlsVisable(Control[] ctrls, bool flag)
        {            
            foreach (Control c in ctrls)
            {
                c.Visible = flag;
            }
        }

        /// <summary>
        /// 更新控件显示，对于groupbox 那么下面的radiobutton 也会做相应显示处理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="flag"></param>
        /// <param name="lst"></param>
        private void updateCtrlVisable(Control ctrl, bool flag, ref List<ID_NAME> lst)
        {
            int i = 0;
            //更新group 控件及其内部所有控件
            if ((ctrl as GroupBox) != null)
            {
                foreach (Control c in ctrl.Controls)
                {
                    //更新radiobuton，前提是有多少个就显示多少，剩下不显示
                    if ((c as RadioButton) != null)
                    {
                        if (i < lst.Count)
                        {
                            //1_空气
                            c.Text = lst[i].id.ToString() + "_" + lst[i].name;
                            c.Visible = flag;
                            i++;
                        }
                    }
                    else
                    {
                        c.Visible = flag;
                    }
                }
                return;
            }
            else
            {
                ctrl.Visible = flag;
            }

        }

        /// <summary>
        /// 添加一个radio到某个group下
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private void addNewRadioInGroup(Control ctrl, int id, string name)
        {
            if ((ctrl as GroupBox) != null)
            {
                foreach (Control c in ctrl.Controls)
                {
                    //更新radiobuton，前提是有多少个就显示多少，剩下不显示
                    if ((c as RadioButton) != null)
                    {
                        if(c.Visible == true)
                        {
                            continue;
                        }
                        c.Text = id.ToString() + "_" + name;
                        c.Visible = true;
                        break;
                    }
                }
            }
        }
#endregion

        private void butAddItem_Click(object sender, EventArgs e)
        {
            addClassForm.ShowDialog(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /***
             * 
             * 
             */

            //获取当前选择的project
            curProject = int.Parse(this.comboBox1.SelectedItem.ToString().Split('_')[0]);

            //构造数据
            List<ID_NAME> lst = new List<ID_NAME>();
            ID_NAME data = new ID_NAME();

            List<measuring_classify> tmp = allData.getClassFromProject(curProject);

            //这里肯定是null 但是为了其他地方做个参考使用
            if (null != tmp)
            {
                foreach (measuring_classify cls in tmp)
                {
                    data.id = cls.id;
                    data.name = cls.name;
                    lst.Add(data);
                }

            }
            //更新控件显示
            updateCtrlVisable(this.groupClass, true, ref lst);
        }



        private void butDelItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.groupClass.Controls)
            {
                if ((c as RadioButton) != null)
                {
                    if (c.Visible == true && ((RadioButton)c).Checked)
                    {
                        allData.delClass(int.Parse(((RadioButton)c).Text.Split('_')[0]));

                        List<ID_NAME> temp = new List<ID_NAME>();
                        updateCtrlVisable(c, false, ref temp);
                        //TODO 删除数据库classfiy 相关的所有数据

                        break;
                    }
                    
                }
            }

            //把剩下所有的groupbox 里面的内容干掉
            disabelOneGroup(this.groupBox2);
            disabelOneGroup(this.groupBox3);
            disabelOneGroup(this.groupBox4);
            disabelOneGroup(this.groupBox5);
            disabelOneGroup(this.groupBox6);
            //把当前的groupbox 里面的radiobutton 干掉 在上面已经干掉了

           
        }
    }
}
