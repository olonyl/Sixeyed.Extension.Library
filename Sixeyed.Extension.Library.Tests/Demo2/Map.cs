using System;
using System.Linq.Expressions;

namespace Sixeyed.Extension.Library.Tests.Demo2
{
    public class Map<TSource, TTarget>
        where TTarget : class, new()
    {
        public TSource Source { get; set; }
        public TTarget Target { get; set; }

        public Map(TSource source)
        {
            Source = source;
            Target = new TTarget();
        }
        public Map<TSource, TTarget> Populate(string targetPropertyName, string sourcePropertyName)
        {
            var targetAccessor = typeof(TTarget).GetProperty(targetPropertyName);
            var sourceAccessor = typeof(TSource).GetProperty(sourcePropertyName);
            targetAccessor.SetValue(Target, sourceAccessor.GetValue(Source));
            return this;
        }

        public Map<TSource, TTarget> Populate<T>(string targetPropertyName, Func<TSource, T> sourceValue)
        {
            var targetAccessor = typeof(TTarget).GetProperty(targetPropertyName);
            targetAccessor.SetValue(Target, sourceValue(Source));
            return this;
        }

        public Map<TSource, TTarget> Populate<T>(Expression<Func<TTarget, T>> targetAccessor, Func<TSource, T> sourceValue)
        {
            var targetPropertyInfo = targetAccessor.ToPropertyInfo();
            targetPropertyInfo.SetValue(Target, sourceValue(Source));
            return this;
        }

    }


}
