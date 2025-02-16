using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace lb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        // Thread

        [HttpGet("thread1")]
        public IActionResult ThreadExample1()
        {
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("[Thread 1] STart...");
                Thread.Sleep(1000);
                Console.WriteLine("[Thread 1] End.");
            });

            thread.Start();
            thread.Join();

            return Ok("Thread 1 has been stopped.");
        }

        [HttpGet("thread2")]
        public IActionResult ThreadExample2()
        {
            Thread thread = new Thread(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"[Thread 2] Iteration {i}");
                    Thread.Sleep(500);
                }
            });

            thread.Start();
            thread.Join();

            return Ok("Thread 2 has been stopped.");
        }

        [HttpGet("thread3")]
        public IActionResult ThreadExample3()
        {
            Thread thread1 = new Thread(() => Console.WriteLine("[Thread 3] Thread 1 is working"));
            Thread thread2 = new Thread(() => Console.WriteLine("[Thread 3] Thread 2 is working"));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            return Ok("Thread 3 has been stopped.");
        }

        // Async-Await

        [HttpGet("async1")]
        public async Task<IActionResult> AsyncExample1()
        {
            Console.WriteLine("[Async 1] Start...");
            await Task.Delay(2000);
            Console.WriteLine("[Async 1] End.");

            return Ok("Async 1 has been stopped.");
        }

        [HttpGet("async2")]
        public async Task<IActionResult> AsyncExample2()
        {
            Console.WriteLine("[Async 2] Loading...");
            await Task.Delay(1500);
            Console.WriteLine("[Async 2] Data has been loaded.");

            return Ok("Async 2 stopped.");
        }

        [HttpGet("async3")]
        public async Task<IActionResult> AsyncExample3()
        {
            async Task<int> GetNumber()
            {
                await Task.Delay(1000);
                return new Random().Next(1, 100);
            }

            int number = await GetNumber();
            Console.WriteLine($"[Async 3] Number: {number}");

            return Ok($"Async 3 has been stopped. Number: {number}");
        }
    }
}