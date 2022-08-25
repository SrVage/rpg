namespace Code.Components.Common
{
    public struct Health
    {
        public float Percent => (float)Value / (float)Maximum;
        public int Value;
        public int Maximum;
    }
}