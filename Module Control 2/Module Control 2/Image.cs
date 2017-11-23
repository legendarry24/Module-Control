namespace Module_Control_2
{
    class Image: BaseFile
    {
        public string Resolution { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + $"MB\n\t\tResolution: {Resolution}";
        }
    }
}
