# How to use a custom font icon for Expander in Xamarin.Forms (SfExpander)

You can customize the expander header icon with font icons in Xamarin.Forms [SfExpander](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Expander.XForms~Syncfusion.XForms.Expander.SfExpander.html?). Please follow the steps below to use the font icons in the Expander [Header](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Expander.XForms~Syncfusion.XForms.Expander.SfExpander~Header.html?) element.

You can also refer the following article.

https://www.syncfusion.com/kb/11469/how-to-use-a-custom-font-icon-for-expander-in-xamarin-forms-sfexpander

**Step 1:** Place the ttf file in the shared code project and set the [Build action](https://docs.microsoft.com/en-us/visualstudio/ide/build-actions?view=vs-2019) as follows,

 **Project** | **Location** | **Build action** 
-------------|--------------|------------------
 Android     | Assets       | AndroidAsset     
 iOS         | Resources    | BundleResource   
 UWP         | Assets       | Content          


In addition, add the name of the font file in the info.plist file of iOS project.
``` xml
<key>UIAppFonts</key> 
<array> 
    <string>ExpanderIcons.ttf</string> 
</array> 
```
You can also refer to the link below to use custom fonts in Xamarin.Forms.

https://xamarinhelp.com/custom-fonts-xamarin-forms/

**Step 2:** In [ResourceDictionary](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.resourcedictionary), define the font to use the custom font as [StaticResource](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.xaml.staticresourceextension).
``` xml
<ContentPage.Resources>
    <ResourceDictionary>
        <OnPlatform x:TypeArguments="x:String" x:Key="ExpanderIcon">
            <On Platform="Android" Value="ExpanderIcons.ttf#ExpanderIcons" />
            <On Platform="UWP" Value="/Assets/ExpanderIcons.ttf#ExpanderIcons" />
            <On Platform="iOS" Value="ExpanderIcons" />
        </OnPlatform>
    </ResourceDictionary>
    <local:ExpanderIconConverter x:Key="ExpanderIconConverter"/>
</ContentPage.Resources>
```
**Step 3:** Bind the [FontFamily](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.xaml.staticresourceextension) for [Label](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.label) using resource key. Use [converter](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/data-binding/converters) to display platform specific icons and bind the Device platform using [RuntimePlatform](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.device.runtimeplatform?view=xamarin-forms) to specify the platform in the **ConverterParameter**. Set [HeaderIconPosition](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.Expander.XForms~Syncfusion.XForms.Expander.SfExpander~HeaderIconPosition.html?) as **None** to hide the default Header icon.
``` xml
<ContentPage.Content>
        <ScrollView BackgroundColor="#EDF2F5" Margin="{OnPlatform iOS='0,40,0,0'}">
            <StackLayout>
                <syncfusion:SfExpander x:Name="expander1">
                    <syncfusion:SfExpander.Header>
                        <Grid HeightRequest="50">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70"/>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="70"/>
                            </Grid.ColumnDefinitions>
                            <Label HorizontalOptions="Center" VerticalOptions="Center"
                                FontFamily="{StaticResource ExpanderIcon}"
                                Text="{Binding Path=IsExpanded,Source={x:Reference expander1}, Converter={StaticResource ExpanderIconConverter}, ConverterParameter={x:Static Device.RuntimePlatform}}"/>
                            <Label Text="Invoice Date" Grid.Column="1" TextColor="#495F6E"  VerticalTextAlignment="Center" />
                            <Label HorizontalOptions="Center" VerticalOptions="Center" Grid.Column="2"
                                FontFamily="{StaticResource ExpanderIcon}"
                                Text="{Binding Path=IsExpanded,Source={x:Reference expander1}, Converter={StaticResource ExpanderIconConverter}, ConverterParameter={x:Static Device.RuntimePlatform}}"/>
                        </Grid>
                    </syncfusion:SfExpander.Header>
                    <syncfusion:SfExpander.Content>
                        <Grid Padding="10,10,10,10" BackgroundColor="#FFFFFF">
                            <Label BackgroundColor="#FFFFFF" HeightRequest="50" Text="Veg pizza is prepared with the items that meet vegetarian standards by not including any meat or animal tissue products." TextColor="#303030" VerticalTextAlignment="Center"/>
                        </Grid>
                    </syncfusion:SfExpander.Content>
                </syncfusion:SfExpander>
            </StackLayout>
        </ScrollView>
    </ContentPage.Content>
```
**Step 4:** Converter to display the platform based icons.
``` c#
namespace ExpanderXamarin
{
 public class ExpanderIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                if ((string)parameter == "Android")
                    return "\ue704";
                else if((string)parameter == "iOS")
                    return "\ue700";
                else
                    return "\ue702";
            }
            else
            {
                if ((string)parameter == "Android")
                    return "\ue705";
                else if ((string)parameter == "iOS")
                    return "\ue701";
                else
                    return "\ue703";
            }
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
```
**Output**

![CustomFontIconExpander](https://github.com/SyncfusionExamples/custom-font-icon-expander-xamarin/blob/master/ScreenShots/CustomFontIconExpander.png)
