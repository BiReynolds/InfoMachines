namespace Core1
{
    public static class AddressHelper
    {
        public static int[] GetAddressUnion(int[][] addressSetList)
        {
            int[] result = new int[addressSetList.Sum((x)=>{ return x.Length; })];
            int currChunkStart = 0;
            foreach (int[] addressSet in addressSetList)
            {
                addressSet.CopyTo(result, currChunkStart);
                currChunkStart += addressSet.Length;
            }
            return result;
        }

        public static bool CheckContainsAll(int[] containingSet, int[] containedSet)
        {
            foreach (int address in containedSet)
            {
                if (!containingSet.Contains(address))
                {
                    return false;
                }
            }
            return true;
        }
    }
}