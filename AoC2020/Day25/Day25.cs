using System;

/*

--- Day 25: Combo Breaker ---

You finally reach the check-in desk.
Unfortunately, their registration systems are currently offline, and they cannot check you in.
Noticing the look on your face, they quickly add that tech support is already on the way!
They even created all the room keys this morning;
you can take yours now and give them your room deposit once the registration system comes back online.

The room key is a small RFID card.
Your room is on the 25th floor and the elevators are also temporarily out of service, so it takes what little energy you have left to even climb the stairs and navigate the halls.
You finally reach the door to your room, swipe your card, and - beep - the light turns red.

Examining the card more closely, you discover a phone number for tech support.

"Hello! How can we help you today?" You explain the situation.

"Well, it sounds like the card isn't sending the right command to unlock the door.
If you go back to the check-in desk, surely someone there can reset it for you."
Still catching your breath, you describe the status of the elevator and the exact number of stairs you just had to climb.

"I see! Well, your only other option would be to reverse-engineer the cryptographic handshake the card does with the door and then inject your own commands into the data stream, but that's definitely impossible."
You thank them for their time.

Unfortunately for the door, you know a thing or two about cryptographic handshakes.

The handshake used by the card and the door involves an operation that transforms a subject number.
To transform a subject number, start with the value 1.
Then, a number of times called the loop size, perform the following steps:

Set the value to itself multiplied by the subject number.
Set the value to the remainder after dividing the value by 20201227.
The card always uses a specific, secret loop size when it transforms a subject number.
The door always uses a different, secret loop size.

The cryptographic handshake works like this:

The card transforms the subject number of 7 according to the card's secret loop size.
The result is called the card's public key.
The door transforms the subject number of 7 according to the door's secret loop size.
The result is called the door's public key.

The card and door use the wireless RFID signal to transmit the two public keys (your puzzle input) to the other device.
Now, the card has the door's public key, and the door has the card's public key.
Because you can eavesdrop on the signal, you have both public keys, but neither device's loop size.
The card transforms the subject number of the door's public key according to the card's loop size.
The result is the encryption key.
The door transforms the subject number of the card's public key according to the door's loop size.
The result is the same encryption key as the card calculated.
If you can use the two public keys to determine each device's loop size, you will have enough information to calculate the secret encryption key that the card and door use to communicate; this would let you send the unlock command directly to the door!

For example, suppose you know that the card's public key is 5764801.
With a little trial and error, you can work out that the card's loop size must be 8, because transforming the initial subject number of 7 with a loop size of 8 produces 5764801.

Then, suppose you know that the door's public key is 17807724.
By the same process, you can determine that the door's loop size is 11, because transforming the initial subject number of 7 with a loop size of 11 produces 17807724.

At this point, you can use either device's loop size with the other device's public key to calculate the encryption key.

Transforming the subject number of 17807724 (the door's public key) with a loop size of 8 (the card's loop size) produces the encryption key, 14897079.
(Transforming the subject number of 5764801 (the card's public key) with a loop size of 11 (the door's loop size) produces the same encryption key: 14897079.)

What encryption key is the handshake trying to establish?

*/

namespace Day25
{
    class Program
    {
        const int MAX_COUNT_LOOPS = 16 * 1024 * 1024;
        const long SEQUENCE_MOD = 20201227L;
        const long DOOR_CARD_SUBJECT_NUMBER = 7L;

        static long sDoorPublicKey;
        static long sCardPublicKey;
        static int sDoorLoopSize;
        static int sCardLoopSize;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day25 : Result1 {result1}");
                var expected = 448851;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day25 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Parse(string[] lines)
        {
            sCardPublicKey = long.Parse(lines[0]);
            sDoorPublicKey = long.Parse(lines[1]);
        }

        private static void FindLoops(long subjectNumber)
        {
            var value = 1L;
            sDoorLoopSize = -1;
            sCardLoopSize = -1;
            for (var i = 0; i < MAX_COUNT_LOOPS; ++i)
            {
                value *= subjectNumber;
                value %= SEQUENCE_MOD;
                if ((sDoorLoopSize == -1) && (value == sDoorPublicKey))
                {
                    sDoorLoopSize = i + 1;
                }
                if ((sCardLoopSize == -1) && (value == sCardPublicKey))
                {
                    sCardLoopSize = i + 1;
                }
                if ((sDoorLoopSize != -1) && (sCardLoopSize != -1))
                {
                    return;
                }
            }
            throw new InvalidProgramException($"Failed to find targets {sDoorPublicKey} {sCardPublicKey} after {MAX_COUNT_LOOPS} loops");
        }

        private static long Encrypt(long subjectNumber, int countLoops)
        {
            var value = 1L;
            for (var i = 0; i < countLoops; ++i)
            {
                value *= subjectNumber;
                value %= SEQUENCE_MOD;
            }
            return value;
        }

        public static long Part1(string[] lines)
        {
            Parse(lines);
            FindLoops(DOOR_CARD_SUBJECT_NUMBER);
            var doorEncrypt = Encrypt(sCardPublicKey, sDoorLoopSize);
            var cardEncrypt = Encrypt(sDoorPublicKey, sCardLoopSize);

            if (doorEncrypt != cardEncrypt)
            {
                throw new InvalidProgramException($"doorEncrypt != cardEncrypt {doorEncrypt} != {cardEncrypt}");
            }
            return doorEncrypt;
        }

        public static long Part2(string[] lines)
        {
            Parse(lines);
            throw new NotImplementedException();
        }

        public static void Run()
        {
            Console.WriteLine("Day25 : Start");
            _ = new Program("Day25/input.txt", true);
            //_ = new Program("Day25/input.txt", false);
            Console.WriteLine("Day25 : End");
        }
    }
}
