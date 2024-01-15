using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PersonalInfomrationProject.Base
{
    public static class LinqExtensions
    {
        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this IEnumerable<TSource> list)
        {
            try
            {
                return new ObservableCollection<TSource>(list);
            }
            catch
            {
                return new ObservableCollection<TSource>();
            }
        }

        public static ObservableCollection<TSource> ToObservableCollection<TSource>(this List<TSource> list)
        {
            try
            {
                return new ObservableCollection<TSource>(list);
            }
            catch
            {
                return new ObservableCollection<TSource>();
            }
        }
    }
}
