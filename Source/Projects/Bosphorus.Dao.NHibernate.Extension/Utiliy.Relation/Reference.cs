using System;
using System.Linq.Expressions;

namespace Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation
{
    public class Reference<TModel> 
        where TModel : new()
    {
        private static Action<TModel, object> setAction;

        public static TModel WithId(Expression<Func<TModel, object>> idPropertyExpression, object id)
        {
            if (id == null)
            {
                return default(TModel);
            }

            if (setAction == null)
            {
                setAction = BuildSetAction(idPropertyExpression);
            }

            TModel model = new TModel();
            setAction(model, id);
            return model;
        }

        private static Action<TModel, object> BuildSetAction(Expression<Func<TModel, object>> idPropertyExpression)
        {
            MemberExpression memberExpression = GetMemberExpression(idPropertyExpression);
            ParameterExpression modelParameterExpression = idPropertyExpression.Parameters[0];
            ParameterExpression idValueExpression = Expression.Parameter(typeof(object));
            UnaryExpression convertExpression = Expression.Convert(idValueExpression, memberExpression.Type);
            BinaryExpression bodyExpression = Expression.Assign(memberExpression, convertExpression);

            Expression<Action<TModel, object>> expression = Expression.Lambda<Action<TModel, object>>(bodyExpression, modelParameterExpression, idValueExpression);
            Action<TModel, object> result = expression.Compile();
            return result;
        }

        private static MemberExpression GetMemberExpression(Expression<Func<TModel, object>> expression)
        {
            var body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            return body;
        }
    }
}
