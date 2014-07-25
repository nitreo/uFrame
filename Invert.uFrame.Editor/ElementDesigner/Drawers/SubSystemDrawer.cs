using System.Collections.Generic;
using System.Linq;
using Invert.Common;
using UnityEngine;

public class SubSystemDrawer : DiagramNodeDrawer<SubSystemData>
{
    private NodeItemHeader _transitionsHeader;

    public override GUIStyle BackgroundStyle
    {
        get
        {

            return ElementDesignerStyles.DiagramBox1;
        }
    }

    public SubSystemDrawer()
    {
    }

    public SubSystemDrawer(SubSystemData data, ElementsDiagram diagram)
        : base(data, diagram)
    {
        Diagram = diagram;

    }

    public override bool AllowCollapsing
    {
        get { return false; }
    }

    public NodeItemHeader TransitionsHeader
    {
        get { return _transitionsHeader ?? (_transitionsHeader = new NodeItemHeader() { Label = "Types", HeaderType = typeof(IDiagramNode) }); }
        set { _transitionsHeader = value; }
    }

    protected override IEnumerable<DiagramSubItemGroup> GetItemGroups()
    {
        if (!Data.Items.Any()) yield break;
        yield return new DiagramSubItemGroup()
        {
            Header = TransitionsHeader,
            Items = Data.Items.ToArray()
        };
    }

    public override GUIStyle ItemStyle
    {
        get { return ElementDesignerStyles.Item4; }
    }

}