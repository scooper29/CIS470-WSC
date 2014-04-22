using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WSCAutomation.App
{
	// Solution based on the answer from this question:
	// http://stackoverflow.com/questions/4164356/edit-datagridview-via-designer-in-inherited-usercontrol

	[Designer(typeof(ControlDesigner))]
	public class InheritableDataGridView : DataGridView
	{
		public InheritableDataGridView()
			: base()
		{
		}
	};
}