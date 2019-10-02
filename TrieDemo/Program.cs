using System;

namespace TrieDemo
{
    class Program
    {
        static readonly int ALPHABET_SIZE = 26;
        static void Main(string[] args)
        {
            string[] keys = { "the", "a", "there", "answer", "any", "by", "bye", "their" };
            string[] output = { "Not present", "present" };

            root = new TrieNode();

            for (int i = 0; i < keys.Length; i++)
            {
                Insert(keys[i]);
            }

            if (Search("the"))
                Console.WriteLine($"th --- {output[1]}");
            
            if(Search("be"))
                Console.WriteLine($"bye --- {output[1]}");
            else
                Console.WriteLine($"bye --- {output[0]}");
        }

        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

            public bool isEndofWord;
            public TrieNode()
            {
                isEndofWord = false;
                for (int i = 0; i < ALPHABET_SIZE; i++)
                {
                    children[i] = null;
                }
            }
        }

        static TrieNode root;

        static void Insert(string key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            pCrawl.isEndofWord = true;
        }

        static bool Search(string key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;
                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndofWord);
        }
    }

   
}
