namespace GrafFeladat_CSharp
{
    class El
    {
        public int Csucs1 { get; private set; }
        public int Csucs2 { get; private set; }

        public El(int csucs1, int csucs2)
        {
            this.Csucs1 = csucs1;
            this.Csucs2 = csucs2;
        }

        public override string ToString()
        {
            return string.Format("({0} - {1})", Csucs1, Csucs2);
        }
    }
}
