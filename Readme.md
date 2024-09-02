<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128651234/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1530)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid - How to Apply Custom Rules to Group Rows

This example shows how to apply custom rules to group rows. When you group data by the Unit Price column, rows in this column that have values between 0 and 10 are combined into a single group. Rows whose values fall between 10 and 20 are combined into another group, and so forth.

![](https://docs.devexpress.com/WPF/images/GridControl_CustomColumnGroupCommand.png)

<!-- default file list -->

## Files to Look At

### Code Behind Technique

- [MainWindow.xaml](./CS/CustomGrouping_CodeBehind/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomGrouping_CodeBehind/MainWindow.xaml))
- [MainWindow.xaml.cs](./CS/CustomGrouping_CodeBehind/MainWindow.xaml.cs#L39-L62) ([MainWindow.xaml.vb](./VB/CustomGrouping_CodeBehind/MainWindow.xaml.vb#L42-L68))

### MVVM Technique

- [MainWindow.xaml](./CS/CustomGrouping_MVVM/MainWindow.xaml) ([MainWindow.xaml](./VB/CustomGrouping_MVVM/MainWindow.xaml))
- [MainViewModel.cs](./CS/CustomGrouping_MVVM/MainViewModel.cs#L33-L57) ([MainViewModel.vb](./VB/CustomGrouping_MVVM/MainViewModel.vb#L36-L63))

<!-- default file list end -->

## Documentation

- [Grouping](https://docs.devexpress.com/WPF/7357/controls-and-libraries/data-grid/grouping)
- [Group Modes and Custom Grouping](https://docs.devexpress.com/WPF/6139/controls-and-libraries/data-grid/grouping/group-modes-and-custom-grouping)
- [CustomColumnGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomColumnGroup)
- [CustomGroupDisplayText](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomGroupDisplayText)
- [CustomColumnGroupCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomColumnGroupCommand)
- [CustomGroupDisplayTextCommand](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.CustomGroupDisplayTextCommand)

## More Examples

- [WPF Data Grid - Display Custom Text Within Data Cells](https://github.com/DevExpress-Examples/how-to-display-custom-text-within-dxgrid-cells-e2020)
- [WPF Data Grid - Prevent Expand and Collapse Operations for Group Rows](https://github.com/DevExpress-Examples/wpf-grid-prevent-expand-collapse-operations-for-group-rows)
- [WPF Data Grid - Sort Group Rows by Summary Values](https://github.com/DevExpress-Examples/how-to-sort-group-rows-by-summary-values-e1540)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-implement-custom-grouping&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-implement-custom-grouping&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
