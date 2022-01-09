using System.Windows.Forms;

namespace Sigame
{
    public class DataGridViewButtonDisableColumn : DataGridViewButtonColumn
    {
        public DataGridViewButtonDisableColumn()
        {
            this.CellTemplate = new DataGridViewButtonDisableCell();
        }
    }
}
