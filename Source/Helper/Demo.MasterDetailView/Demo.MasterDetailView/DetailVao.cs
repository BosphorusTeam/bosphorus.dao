using System;
using System.Collections.Generic;
using System.Text;
using NQuery;
using NQuery.Extension.Executer;

namespace Demo.MasterDetailView
{
    public class DetailVao
    {
        private const string NQUERY_SQL_SELECT = @"
            select
                    Detail as Detail
            from
                    Detail
            ";

        public IList<DetailView> GetAll()
        {
            IList<Detail> modelList = GetModelList();
            IList<DetailView> result = GetView(modelList);
            return result;
        }

        private IList<DetailView> GetView(IList<Detail> modelList)
        {
            DataContext dataContext = new DataContext();
            dataContext.Tables.Add(modelList, "Detail");

            Query query = new Query(dataContext);
            query.Text = NQUERY_SQL_SELECT;

            IList<DetailView> result = QueryExecuter.Execute(query).ToModel<DetailView>();
            return result;
        }

        private IList<Detail> GetModelList()
        {
            IList<Detail> modelList = new List<Detail>();
            modelList.Add(new Detail(1));
            modelList.Add(new Detail(2));

            return modelList;
        }
    }
}
