namespace CSharp_Utils
{
    public class ExtendableMemory
    {
        byte[] memory;
        int memoryPosition;
        int PortionSize { get; }
        int GrowSpeed { get; }
        public byte[] Get { get => this.memory; }
        public ExtendableMemory(int defaultPortionSize = 4096, int growSpeed = 4)
        {
            this.PortionSize = defaultPortionSize;
            this.memory = new byte[defaultPortionSize];
            this.GrowSpeed = growSpeed;
            this.memoryPosition = 0;
        }

        public void Push(byte[] portion)
        {
            if (ShouldExpandMemory(portion.Length))
            {
                var expandedArray = new byte[memory.Length * GrowSpeed];
                System.Array.Copy(memory, expandedArray, PortionSize);
                this.memory = expandedArray;

            }
            System.Array.Copy(portion, 0, memory, memoryPosition, portion.Length);
            this.memoryPosition += portion.Length;
        }

        public void Push(byte[] array, int length)
        {
            if (ShouldExpandMemory(length))
            {
                var expandedArray = new byte[memory.Length * GrowSpeed];
                System.Array.Copy(memory, expandedArray, PortionSize);
                this.memory = expandedArray;

            }
            System.Array.Copy(array, 0, memory, memoryPosition, length);
            this.memoryPosition += array.Length;
        }


        private int AvailableMemory()
        {
            return this.memory.Length - memoryPosition;
        }

        private bool ShouldExpandMemory(int portionSize)
        {
            return AvailableMemory() <= portionSize;
        }
    }
}