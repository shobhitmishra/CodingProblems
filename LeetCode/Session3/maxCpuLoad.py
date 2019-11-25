from heapq import *

class job:
    def __init__(self, start, end, cpu_load):
        self.start = start
        self.end = end
        self.cpu_load = cpu_load

    def __lt__(self, other):
        # min heap based on meeting.end
        return self.end < other.end


def find_max_cpu_load(jobs):
    # TODO: Write your code here
    jobs.sort(key = lambda x: x.start)
    jobHeap = []
    maxSum, sumTotalSoFar = 0,0
    for _, job in enumerate(jobs):
        while len(jobHeap) > 0 and jobHeap[0].end <= job.start:
            sumTotalSoFar -= jobHeap[0].cpu_load
            heappop(jobHeap)
        heappush(jobHeap, job)
        sumTotalSoFar += job.cpu_load
        maxSum = max(maxSum, sumTotalSoFar)
    return maxSum


def main():
  print("Maximum CPU load at any time: " + str(find_max_cpu_load([job(1, 4, 3), job(2, 5, 4), job(7, 9, 6)])))
  print("Maximum CPU load at any time: " + str(find_max_cpu_load([job(6, 7, 10), job(2, 4, 11), job(8, 12, 15)])))
  print("Maximum CPU load at any time: " + str(find_max_cpu_load([job(1, 4, 2), job(2, 4, 1), job(3, 6, 5)])))


main() 