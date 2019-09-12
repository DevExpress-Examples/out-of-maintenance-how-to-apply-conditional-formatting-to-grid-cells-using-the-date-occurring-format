using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;

namespace Grid_DateOccurring {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();

            dashboardViewer1.DataSourceOptions.ObjectDataSourceLoadingBehavior = DevExpress.DataAccess.DocumentLoadingBehavior.LoadAsIs;

            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridDimensionColumn date = (GridDimensionColumn)grid.Columns[0];

            GridItemFormatRule dateOccurringRule = new GridItemFormatRule(date);
            FormatConditionDateOccurring dateOccurringCondition = new FormatConditionDateOccurring();
            dateOccurringCondition.DateType = FilterDateType.MonthAgo1 | FilterDateType.MonthAgo2;
            dateOccurringCondition.StyleSettings = 
                new AppearanceSettings(FormatConditionAppearanceType.PaleOrange);
            dateOccurringRule.Condition = dateOccurringCondition;
            dateOccurringRule.ApplyToRow = true;

            grid.FormatRules.Add(dateOccurringRule);            
        }
    }
}
