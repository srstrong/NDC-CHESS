using Atomicity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace AccountTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ConcurrentDebitCredit_TheOldWay()
        {
            for (var i = 0; i < 1000; i++)
            {
                var a = new Account();

                Parallel.Invoke(() => a.Credit(100),
                                () => a.Debit(50));

                Assert.AreEqual(50, a.CurrentBalance);
            }
        }

        [TestMethod]
        [HostType("Chess")]
        [TestProperty("ChessMode", "Repro")]
        [TestProperty("ChessBreak", "BeforePreemption,AfterPreemption")]
        #region ChessScheduleString (not human readable)
        [TestProperty("ChessScheduleString", @"bpilaiaaaaaaaaaaaeaaonlnahgabmejjgcfcgcpgnmkhlhpekpfeknhoahekbaiiagabdcenijaeabaommbiimnogjcombngjeh
cdcjklckibmkgffggffnggbgeammonjnlmphnohloplnphnohloplnphlkdljneochphnpppdpfmgggeabgmpgmoeknkmjjocbia
kkmibpdphohmbpdpcchomnfpodnhpidfpappbpndjpppphkpcjdpmnoplpifpopoglnbpphpfnpnpnnhpghomhohognnfpflhppp
lfpepplpjopomedplpkfhoppglolohpiijhhhoanpnojphgfpogpbopdllibphblkapnppadjbhjcndpljaaaaaa")]
        #endregion
        public void ConcurrentDebitCredit()
        {
            var a = new Account();

            Parallel.Invoke(() => a.Credit(100),
                            () => a.Debit(50));

            Assert.AreEqual(50, a.CurrentBalance);
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
