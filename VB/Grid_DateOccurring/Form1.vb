Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors

Namespace Grid_DateOccurring
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboardViewer1.Dashboard = dashboard
            Dim grid As GridDashboardItem =
                CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim [date] As GridDimensionColumn = CType(grid.Columns(0), GridDimensionColumn)

            Dim dateOccuringRule As New GridItemFormatRule([date])
            Dim dateOccuringCondition As New FormatConditionDateOccuring()
            dateOccuringCondition.DateType = FilterDateType.MonthAgo1 Or FilterDateType.MonthAgo2
            dateOccuringCondition.StyleSettings =
                New AppearanceSettings(FormatConditionAppearanceType.PaleOrange)
            dateOccuringRule.Condition = dateOccuringCondition
            dateOccuringRule.ApplyToRow = True

            grid.FormatRules.Add(dateOccuringRule)
        End Sub
    End Class
End Namespace
