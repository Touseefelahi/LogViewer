	
	This goes in Xaml

	<Window x:Class="TestApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:logger="clr-namespace:LoggerControl.Views;assembly=LoggerControl"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TestApp"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
		<Grid>
			<logger:LogControl x:Name="LogView" />
		</Grid>
	</Window>


	Set the Datacontext in code behind

	var logger = new Logger.Core.Logger();
    LogView.DataContext = new Logger.Core.LogControlViewModel(logger);
    logger.Log("Test App working");