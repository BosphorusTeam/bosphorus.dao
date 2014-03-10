using System;
using System.Collections.Generic;
using System.Text;
using NQuery;
using NQuery.Extension.Executer;
using NQuery.Runtime;
using System.Collections;

namespace Demo.MasterDetailView
{
    public class MasterVao
    {
                    //GetDetailView(Master.DetailList) as DetailViewList
        private const string NQUERY_SQL_SELECT = @"
            select
                    Master as Master,
                    GetDetailView(Master.DetailList) as DetailViewList
            from
                    Master
            ";

        public IList<MasterView> GetAll()
        {
            IList<Master> modelList = GetModelList();
            IList<MasterView> result = GetView(modelList);
            return result;
        }

        private IList<DetailView> GetDetailList()
        {
            return new DetailVao().GetAll();
        }

        private IList<MasterView> GetView(IList<Master> modelList)
        {
            DataContext dataContext = new DataContext();
            dataContext.Tables.Add(modelList, "Master");
            dataContext.Functions.AddFromContainer(this);

            Query query = new Query(dataContext);
            query.Text = NQUERY_SQL_SELECT;

            IList<MasterView> result = QueryExecuter.Execute(query).ToModel<MasterView>();
            return result;
        }

        [FunctionBinding("GetDetailView", IsDeterministic = true)]
        public object GetDetailView(IEnumerable enumerable)
        {
            return new DetailVao().GetAll();
        }

        private IList<Master> GetModelList()
        {
            IList<Master> modelList = new List<Master>();
            modelList.Add(new Master(1, "Onur"));
            modelList.Add(new Master(2, "Eker"));

            return modelList;
        }
    }
}
