using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// See https://stackoverflow.com/questions/20711986/entity-framework-code-first-cant-store-liststring
namespace System.Collections.Specialized
{
    [ComplexType]
    public abstract class ScalarCollectionBase<T> : Collection<T>
    {
        public virtual string Separator { get; } = "\n";
        public virtual string ReplacementChar { get; } = " ";

        public ScalarCollectionBase(params T[] values)
        {
            if (values != null)
                foreach (var item in Items)
                    Items.Add(item);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Not to be used directly by user, use Items property instead.")]
        public string Data
        {
            get
            {
                var data = Items.Select(item => Serialize(item)
                    .Replace(Separator, ReplacementChar.ToString()));
                return string.Join(Separator, data.Where(s => s?.Length > 0));
            }
            set
            {
                Items.Clear();
                if (string.IsNullOrWhiteSpace(value))
                    return;

                foreach (var item in value
                    .Split(new[] { Separator },
                        StringSplitOptions.RemoveEmptyEntries).Select(item => Deserialize(item)))
                    Items.Add(item);
            }
        }

        public void AddRange(params T[] items)
        {
            if (items != null)
                foreach (var item in items)
                    Add(item);
        }

        protected virtual string Serialize(T item) => item.ToString();
        protected virtual T Deserialize(string item) => (T) Convert.ChangeType(item, typeof(T));
    }

}