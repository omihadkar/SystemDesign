using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LeetCode
{
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

    class AddTwoNumbers
    {

        static void Main(string[] args)
        {
            /*Sample Input-1*/
            //ListNode l1 = new ListNode() { val = 2, next = new ListNode() { val = 4, next = new ListNode() { val = 3, next = null } } };
            //ListNode l2 = new ListNode() { val = 5, next = new ListNode() { val = 6, next = new ListNode() { val = 4, next = null } } };

            /*Sample Input-2*/
            ListNode l1 = new ListNode() { val = 1, next = new ListNode() { val = 8, next = null } };
            ListNode l2 = new ListNode() { val = 0, next= null };

            AddTwoNumbers adt = new AddTwoNumbers();
           var res=  adt.AddTwoNumbersMethod(l1, l2);
        }

        public ListNode AddTwoNumbersMethod(ListNode l1, ListNode l2)
        {
            int carry = 0;
            int firstDigit = 0;
            int a, b;
            ListNode l3 = null;
            ListNode p = null;
            ListNode temp = null;

            ListNode lst = new ListNode();

            while (l1 != null || l2 != null || carry!=0 )
            {
                if (l1==null)
                {
                    a = 0;
                }
                else
                {
                    a = l1.val;
                }

                if (l2==null)
                {
                    b = 0;
                }
                else
                {
                    b = l2.val;
                }

                var result = a+b+carry;
                firstDigit = result % 10;
                carry = result / 10;
                temp = new ListNode(firstDigit);

                if (p==null)
                {
                    p = temp;
                    l3 = p;
                }
                else
                {
                    p.next = temp;
                    p = p.next;
                }

                if (l1!=null)
                {
                    l1 = l1.next;                    
                }

                if (l2!=null)
                {
                    l2 = l2.next;
                }
            }
            return l3;
        }
    }
}
