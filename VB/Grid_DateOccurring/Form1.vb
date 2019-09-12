Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors

Namespace Grid_DateOccurring
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()

			dashboardViewer1.DataSourceOptions.ObjectDataSourceLoadingBehavior = DevExpress.DataAccess.DocumentLoadingBehavior.LoadAsIs

			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
			dashboardViewer1.Dashboard = dashboard
			Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
			Dim [date] As GridDimensionColumn = CType(grid.Columns(0), GridDimensionColumn)

			Dim dateOccurringRule As New GridItemFormatRule([date])
			Dim dateOccurringCondition As New FormatConditionDateOccurring()
			dateOccurringCondition.DateType = FilterDateType.MonthAgo1 Or FilterDateType.MonthAgo2
			dateOccurringCondition.StyleSettings = New AppearanceSettings(FormatConditionAppearanceType.PaleOrange)
			dateOccurringRule.Condition = dateOccuringCondition
			dateOccurringRule.ApplyToRow = True

			grid.FormatRules.Add(dateOccurringRule)
		End Sub
	End Class
End Namespace
