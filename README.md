# AlohaKit Layouts

.NET MAUI **Layouts** Library.

![AlohaKit.Layouts](https://github.com/jsuarezruiz/AlohaKit.Layouts/blob/main/images/alohakit-layouts-promo.png?raw=true)

_NOTE: This library is a port of [XamPane](https://github.com/jsuarezruiz/Xampane)._

## Usage

**Step 1**: Include the AlohaKit.Layouts package reference in your project. 

**Step 2**: Use the **UseAlohaKitLayouts** extension method in your MauiProgram class.

**Step 3**: Enjoy coding!.

### CircularLayout

The CircularLayout is a simple Panel derivative that lays out its children in a **circular** arrangement. It has some useful properties to allow some customization like the Orientation (Clockwise or Counterclockwise).

```
<alohakit:CircularLayout
    Orientation="Clockwise">
    <BoxView Color="Black" CornerRadius="6" WidthRequest="6" HeightRequest="6" />       
    <BoxView Color="Red" CornerRadius="12" WidthRequest="12" HeightRequest="12" alohakit:CircularLayout.Angle="0" alohakit:CircularLayout.Radius="120" />
    <BoxView Color="Green" CornerRadius="12" WidthRequest="12" HeightRequest="12" alohakit:CircularLayout.Angle="10" alohakit:CircularLayout.Radius="120" />
    <BoxView Color="Blue" CornerRadius="12" WidthRequest="12" HeightRequest="12" alohakit:CircularLayout.Angle="20" alohakit:CircularLayout.Radius="120" />
    <BoxView Color="Yellow" CornerRadius="12" WidthRequest="12" HeightRequest="12" alohakit:CircularLayout.Angle="30" alohakit:CircularLayout.Radius="120" />
    <Label Text="1" alohakit:CircularLayout.Angle="30" alohakit:CircularLayout.Radius="90" />
    <Label Text="2" alohakit:CircularLayout.Angle="60" alohakit:CircularLayout.Radius="90" />
    <Label Text="3" alohakit:CircularLayout.Angle="90" alohakit:CircularLayout.Radius="90" />
    <Label Text="4" alohakit:CircularLayout.Angle="120" alohakit:CircularLayout.Radius="90" />
    <Label Text="5" alohakit:CircularLayout.Angle="150" alohakit:CircularLayout.Radius="90" />
    <Label Text="6" alohakit:CircularLayout.Angle="180" alohakit:CircularLayout.Radius="90" />
    <Label Text="7" alohakit:CircularLayout.Angle="210" alohakit:CircularLayout.Radius="90" />
    <Label Text="8" alohakit:CircularLayout.Angle="240" alohakit:CircularLayout.Radius="90" />
    <Label Text="9" alohakit:CircularLayout.Angle="270" alohakit:CircularLayout.Radius="90" />
    <Label Text="10" alohakit:CircularLayout.Angle="300" alohakit:CircularLayout.Radius="90" />
    <Label Text="11" alohakit:CircularLayout.Angle="330" alohakit:CircularLayout.Radius="90" />
    <Label Text="12" alohakit:CircularLayout.Angle="360" alohakit:CircularLayout.Radius="90" />
</alohakit:CircularLayout>
```

![CircularLayout](https://raw.githubusercontent.com/jsuarezruiz/AlohaKit.Layouts/main/images/circularlayout.png)

### DockLayout

The DockLayout allows you to **dock** the child controls to the top, bottom, left or right. By default, the last control, if not given a specific dock position, will fill the remaining space. You can achieve the same with the Grid panel, but for the simpler situations, the DockLayout will be easier to use. Use the DockLayout whenever you need to dock one or several controls to one of the sides, like for dividing up the screen into specific areas.

```
<alohakit:DockLayout
    LastChildFill="False">
    <Button alohakit:DockLayout.Dock="Top" Text="Top" HeightRequest="50"/>
    <Button alohakit:DockLayout.Dock="Bottom" Text="Bottom" HeightRequest="50"/>
    <Button alohakit:DockLayout.Dock="Left" Text="Left" WidthRequest="60"/>
    <Button alohakit:DockLayout.Dock="Left" Text="Left" WidthRequest="60"/>
    <Button alohakit:DockLayout.Dock="Right" Text="Right" WidthRequest="80"/>
    <Button alohakit:DockLayout.Dock="Right" Text="Right" WidthRequest="80"/>
</alohakit:DockLayout>
```

![DockLayout](https://raw.githubusercontent.com/jsuarezruiz/AlohaKit.Layouts/main/images/docklayout.png)

### UniformGrid

The UniformGrid is just like the Grid, with the possibility of multiple rows and columns, but with one important difference: All rows and columns will have the **same size**. Use this when you need the Grid behavior without the need to specify different sizes for the rows and columns.

```
<alohakit:UniformGrid>
    <BoxView Color="Red" />
    <BoxView Color="Yellow" />
    <BoxView Color="Orange" />
    <BoxView Color="Purple" />
    <BoxView Color="Blue" />
    <BoxView Color="Green" />
    <BoxView Color="LightGreen" />
    <BoxView Color="Gray" />
    <BoxView Color="Pink" />
</alohakit:UniformGrid>
```

![UniformGrid](https://raw.githubusercontent.com/jsuarezruiz/AlohaKit.Layouts/main/images/uniformgrid.png)

### WrapLayout

The WrapLayout will position each of its child controls next to the other, horizontally (default) or vertically, until there is no more room, where it will **wrap** to the next line and then continue. Use it when you want a vertical or horizontal collection controls that automatically wraps when there's no more room.

```
<alohakit:WrapLayout 
    Orientation="Vertical"
    Spacing="6"
    HorizontalOptions="Center">
    <BoxView Color="Red" />
    <BoxView Color="Yellow" />
    <BoxView Color="Orange" />
    <BoxView Color="Purple" />
    <BoxView Color="Blue" />
    <BoxView Color="Green" />
    <BoxView Color="LightGreen" />
    <BoxView Color="Gray" />
    <BoxView Color="Pink" />
</alohakit:WrapLayout>
```

![WrapLayout](https://raw.githubusercontent.com/jsuarezruiz/AlohaKit.Layouts/main/images/wraplayout.png)

## Feedback

Please use [GitHub issues](https://github.com/jsuarezruiz/AlohaKit.Layouts/issues) for questions or comments.

## Copyright and license

Code released under the [MIT license](https://opensource.org/licenses/MIT).