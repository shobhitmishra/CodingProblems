l = ["Shobhit Mishra", "Shailendra Mishra", "Archana Rai", "A Rai", "Vaani Mishra", "Joe Kennedy", "Tom Kennedy", "Tanya P", "Rishi P"]
sorted_list = sorted(l, key=lambda name: (name.split()[::-1]))
print(sorted_list)