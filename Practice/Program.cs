using System;

namespace Practice
{
	class Pointer
	{
		internal Pointer next;
		internal Pointer previous;
		internal char value;
		public Pointer(char x)
		{
			this.value = x;
			next = null;
		}
	}

	class Program
	{
		public static char getCharFromList(int i, Pointer head)
		{
			Pointer start = head;
			int k = 1 ;
			while (start!=null)
            {
				if (k == i) break;
				start = start.next;
				k++;
            }

			if ((k > i) || (start ==null))
			{
				Console.WriteLine("Your Index doesn't exist in the list!");
				return '0';
			}
			else return start.value;

		}
		
		public static void removeCharFromList(int x,ref Pointer head)
        {
			Pointer t = head;
			int i = 1;
			while (i<x && t!=null)
            {
				t = t.next;
				i++;
            }
			if (i==1)
            {
				head = head.next;
            }
			else if (i == x) removeFromList(t);
			else Console.WriteLine("Element can't be found");
        }
		public static void removeFromList(Pointer deleted)
        {
			if (deleted.previous != null)
			{
				deleted.previous.next = deleted.next;

			}
			if (deleted.next != null)
			{
				deleted.next.previous = deleted.previous;
				deleted = deleted.next;

			}

			//deleted = null;
        }
		public static void addToListStart(char x, ref Pointer head)
		{
            Pointer t = new Pointer(x);
			t.next = head;
			head.previous = t;
			head = t;
		}
		public static void addToListMiddle(char x,Pointer head)
        {
			Pointer t = head;
			int size = countList(head);
			int i = 1;
			while (i<size/2 && t!=null)
            {
				t = t.next;
				i++;
            }
			head = t;
			t = null;
			t = new Pointer(x);
			t.next = head.next;
			head.next.previous = t;
			head.next = t;
			t.previous = head;

        }
		public static void deleteListMiddle(Pointer head)
        {
			Pointer t = head;
			int size = countList(head);
			int i = 1;
			while (i < size / 2 && t != null)
			{
				t = t.next;
				i++;
			}
			t.previous.next = t.next;
			t.next.previous = t.previous;
			t = null;
		}
		public static void addToList(char x, Pointer head)
		{
			Pointer t = head;
			while (t.next != null)
			{
				t = t.next;
			}
			Pointer addedPointer = new Pointer(x);
			t.next = addedPointer;
			addedPointer.previous = t;
		}
        public static int countList(Pointer head)
        {
            Pointer t = head;
            int k = 0;
            while (t != null)
            {
                k++;
                t = t.next;
            }
            return k;
        }
		public static void printList(Pointer head)
        {
			Pointer start = head;
			Console.Write("-------------List print ------------ \n");
			while (start!=null)
            {
				Console.Write(start.value + " -> ");
				start = start.next;
            }
			Console.Write("\n");
        }
		public static void Main(string[] args)
		{
			Console.Write("Add first element : ");
			char f = Console.ReadLine()[0];
			Pointer head = new Pointer(f);	
			Pointer t = head;
			char option;
			do
			{
				Console.Write(" Enter Option : \n 1-Add Char  \n 2-Count elements \n 3-Get element with [i] \n 4-Print the list \n 5-Delete an element \n 6- Delete From Middle \n 7-Add char in Beginning \n 8-Add char in the Middle \n (0=Exit) ");
				option = Console.ReadLine().ToString()[0];
				switch (option)
				{
					case '1':
						{
							Console.Write("Enter char to add : "); char add = Console.ReadLine().ToString()[0];
							addToList(add, head);
							break;
						}
					case '2':
						{
							Console.WriteLine("Count = " + countList(head));
							break;
						}
					case '3':
						{
							Console.Write("i of Element = "); string n = Console.ReadLine().ToString();
							int k = int.Parse(n);
							Console.WriteLine("Element " + k + " = " + getCharFromList(k, head));
							break;
						}
					case '4':
                        {
							printList(head);
							break;
                        }
					case '5':
                        {
							//Delete from beginning s=1, delete from end s=countList(head), Delete from Middle s=countList(head)/2 ** TESTED **
							Console.Write("Enter i Element do delete : "); int s = int.Parse(Console.ReadLine());
							removeCharFromList(s, ref head);
							break;
                        }
					case '6':
                        {
							deleteListMiddle(head);
							break;
                        }
					case '7':
                        {
							Console.Write("Enter char to add : "); char s = Console.ReadLine().ToString()[0];
							addToListStart(s,ref head);
							break;
                        }
					case '8':
                        {
							Console.Write("Enter char to add (middle) : "); char s = Console.ReadLine().ToString()[0];
							addToListMiddle(s, head);
							break;
                        }
					case '0': break;

				}
			} while (option != '0');

		}
	}
}