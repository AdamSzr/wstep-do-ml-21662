namespace ExtensionMethods
{
    public static class Boolean
    {
        public static bool AND(this bool value, bool arg) => value && arg;
        public static bool _AND(bool value, bool arg) => value && arg;
        public static bool NOT(this bool value) => !value;
        public static bool _NOT(bool value) => !value;
        public static bool OR(this bool value, bool arg) => value || arg;
        public static bool _OR(bool value, bool arg) => value || arg;
        public static bool XOR(this bool value, bool arg) => !value.OR(arg);
        public static bool _XOR(bool value, bool arg) => !value.OR(arg);

    }
}