using System.IO;
using System;

namespace Turing
{
    class Assembler
    {
        private const int COMM_LENGTH = 3;
        private const int ADDR_LENGTH = 6;
        
        static public int Run(bool[] bitcode)
        {
            int b = 0;
            int comm = 0;
            int addr1 = 0;
            int addr2 = 0;
            int ans = -1;
            
            while (true) {
                // Read command
                b += COMM_LENGTH;
                if (b > bitcode.Length)
                    break;
                comm = 0;
                for (int i = 0; i < COMM_LENGTH; i++) {
                    if (bitcode[b - i - 1])
                        comm += (int)Math.Pow(2, i);
                }
                
                // Read arguments
                if (comm != 5) {
                    b += ADDR_LENGTH;
                    if (b > bitcode.Length)
                        break;
                    addr1 = 0;
                    for (int i = 0; i < ADDR_LENGTH; i++) {
                        if (bitcode[b - i - 1])
                            addr1 += (int)Math.Pow(2, i);
                    }
                    
                    if (comm != 7) {
                        b += ADDR_LENGTH;
                        if (b > bitcode.Length)
                            break;
                        addr2 = 0;
                        for (int i = 0; i < ADDR_LENGTH; i++) {
                            if (bitcode[b - i - 1])
                                addr2 += (int)Math.Pow(2, i);
                        }
                    }
                }
                
                if (comm == 0) // Copy
                    bitcode[addr1] = bitcode[addr2];
                else if (comm == 1) // Add
                    bitcode[addr1] ^= bitcode[addr2];
                else if (comm == 2) // And
                    bitcode[addr1] &= bitcode[addr2];
                else if (comm == 3) // Compare
                    bitcode[addr1] = (bitcode[addr1] == bitcode[addr2]);
                else if (comm == 4) // Negate
                    bitcode[addr1] = !bitcode[addr2];
                else if (comm == 6) // Jump
                    if (bitcode[addr2])
                        b = addr1;
                else if (comm == 7) // Return
                    if (bitcode[addr1])
                        ans = 1;
                    else
                        ans = 0;
            }
            
            return ans;
        }
    }
}