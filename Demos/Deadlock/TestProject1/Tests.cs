using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deadlock;
using Utils;

namespace TestProject1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TwoConcurrentTransfersOnTheSameAccountsIsValid()
        {
            for (var i = 0; i < 100; i++)
            {
                var a = new Account(1);
                var b = new Account(2);
                var bank = new Bank();

                Parallel.Invoke(() => bank.Transfer(a, b, 100),
                                () => bank.Transfer(b, a, 100));
            }
        }

        [TestMethod]
        [HostType("Chess")]
        [TestProperty("ChessDebug", "true")]
        [TestProperty("ChessMode", "Repro")]
        [TestProperty("ChessBreak", "Deadlock")]
        #region ChessScheduleString (not human readable)
        [TestProperty("ChessScheduleString", @"bpilaiaaaaaaaaaaaeaaonlnahgabmejjgcfcgcpgnmkhlhpekpfeknhoahekbaiiagabdcenijaeabaommbiimnogjcombngjeh
cdcjklckibmkgffggffnggbgeammonjnlmphnohloplnphnohloplnphlkdljneochphnpppdpfmgggeabgmpgmoeknkmjjocbia
kkmibpdphohmbpdpcchomnfpodnhpidfpappbpndjpppphkpcjdpmnoplpifpopoglnbpphpfnpnpnnhpghomhohognnfpflhppp
lfpepplpjopomedplpjghoppglolohpiijhhhoanpnojphgfpogpbopdllibphblkapnppadjhjcefdiljaaaaaa")]
        #endregion
        public void TwoConcurrentTransfersOnTheSameAccountsIsValid_CHESS()
        {
            var a = new Account(1);
            var b = new Account(2);
            var bank = new Bank();

            Parallel.Invoke(() => bank.Transfer(a, b, 100),
                () => bank.Transfer(b, a, 100));
        }

        /*
        [TestProperty("ChessExpectedResult",X)]
        - "success": CHESS ran the unit test without error (default)
        - "invalidtest": the test failed some CHESS requirement
        - "testfailure": the unit test failed or raised an exception
        - "deadlock": CHESS detected a deadlock
        - "livelock": CHESS detected a livelock
        - "timeout": CHESS aborted the test because it ran over the time limit (10 seconds)
        - "chessfailure" : CHESS experienced an internal failure.

        [TestProperty("ChessBound","N")]
        - number of pre-emptions (default of 2)
        
        [TestProperty("ChessDebug","true")]
        - show progress in console window
        
        [TestProperty("ChessMaxExecs","N")]
        - explore at most N thread schedules

        [TestProperty("ChessBreak", X)]
        - c, beforecontextswitch: break before each context switch
        - C, aftercontextswitch: break after each context switch
        - p, beforepreemption: break before each preemption
        - P, afterpreemption: break after each preemption
        - d, deadlock: break on deadlock
        - t, timeout:  break on timeout of test
        - l, livelock: break on livelock
         
        */
    }
}
