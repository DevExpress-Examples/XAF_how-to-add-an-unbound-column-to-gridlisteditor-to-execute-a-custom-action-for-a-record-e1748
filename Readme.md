<!-- default file list -->
*Files to look at*:

* [SimpleBusinessActionGridListViewController.cs](./CS/WinSolution.Module.Win/SimpleBusinessActionGridListViewController.cs) (VB: [SimpleBusinessActionGridListViewController.vb](./VB/WinSolution.Module.Win/SimpleBusinessActionGridListViewController.vb))
* [Order.cs](./CS/WinSolution.Module/Order.cs) (VB: [Order.vb](./VB/WinSolution.Module/Order.vb))
<!-- default file list end -->
# How to add an unbound column to GridListEditor to execute a custom action for a record


<p>This example shows how to add a custom unbound column to the GridControl in ListView. In the example, a button will be shown in this custom column. When a button is clicked, a custom business action will be executed on the selected record. To be more precise, the boolean Active property of the Order business class will be reversed.<br /> To accomplish this task, we will declare a public SimpleBusinessAction method within the Order class. This will allow to reverse the Active property because for demo purposes it won't have a public setter allowing to set this property directly.<br /> To add a custom unbound column to the GridControl, we will create a new column and configure its editor as needed. To learn more about the GridControl's customizations please refer to the XtraGrid's documentation.</p>
<p>Take special note that XAF Web applications support this scenario out-of-the-box. You can make a method within your business class and mark it with the <a href="http://www.devexpress.com/Help/?document=ExpressApp/clsDevExpressPersistentBaseActionAttributetopic.htm">ActionAttribute</a>. Then, XAF will produce an Action column in the List View for your business class. Refer to the documentation for more details.<br /><br /><strong>IMPORTANT NOTES</strong><br />One of the prerequisites for this particular solution and the DataAccessMode = Server mode is to have a valid IModelMember defined in the Application Model. You can do this via the Model Editor as described in the <a href="https://documentation.devexpress.com/#Xaf/CustomDocument3583">eXpressApp Framework > Concepts > Business Model Design > Types Info Subsystem > Customize Business Object's Metadata</a> article.<br /><br /></p>
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/K18108">How to provide an inline Action shown right within the ListView control row on the Web</a><br /> <a href="http://www.devexpress.com/Help/?document=expressapp/customdocument2739.htm">Access Grid Control Properties</a><br /> <a href="http://www.devexpress.com/Help/?document=XtraGrid/CustomDocument747.htm">Assigning Editors to Individual Cells</a><br /> <a href="http://www.devexpress.com/Help/?document=XtraEditors/CustomDocument1009.htm">Repositories and Repository Items</a><br /> <a href="http://www.devexpress.com/Help/?document=ExpressApp/clsDevExpressPersistentBaseActionAttributetopic.htm">ActionAttribute Class</a></p>

<br/>


