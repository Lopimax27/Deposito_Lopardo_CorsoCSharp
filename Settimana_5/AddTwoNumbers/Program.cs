
// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        string primo = l1.val.ToString();
        string secondo = l2.val.ToString();
        string primoOrdinato = "", secondoOrdinato = "", solOrdinato = "";

        for (int i = primo.Length-1; i >= 0; i--)
        {
            primoOrdinato += primo[i];
        }

        for (int i = secondo.Length-1; i >= 0; i--)
        {
            secondoOrdinato += secondo[i];
        }

        int valSol = int.Parse(primoOrdinato) + int.Parse(secondoOrdinato);
        string valSolStringa = valSol.ToString();

        for (int i = valSolStringa.Length-1; i >= 0; i--)
        {
            solOrdinato += valSolStringa[i];
        }

        return new ListNode(int.Parse(solOrdinato)); 
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ListNode l1 = new ListNode(243);
        ListNode l2 = new ListNode(564);
        Solution s = new Solution();
        ListNode l3 = s.AddTwoNumbers(l1, l2);
        Console.WriteLine(l3.val);
    }
}