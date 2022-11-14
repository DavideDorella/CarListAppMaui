using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CarListAppMaui.ViewModels;

	public partial class BaseViewModel :ObservableObject
	{
	[ObservableProperty]
		string title;
    
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(isNotLoading))]
	
	
	bool isLoading;
	public bool isNotLoading => !isLoading;



	}
