def can_attend_all_appointments(intervals):
  if not intervals:
      return True
  intervals.sort(key = lambda x: x[0])
  end = intervals[0][1]
  for i in range(1, len(intervals)):
    currStart = intervals[i][0]
    if currStart <= end:
        return False
    end = intervals[i][1]
  return True

def main():
  print("Can attend all appointments: " + str(can_attend_all_appointments([[1, 4], [2, 5], [7, 9]])))
  print("Can attend all appointments: " + str(can_attend_all_appointments([[6, 7], [2, 4], [8, 12]])))
  print("Can attend all appointments: " + str(can_attend_all_appointments([[4, 5], [2, 3], [3, 6]])))


main()