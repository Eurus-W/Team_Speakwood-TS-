import json

lines = open("D:\\project\\items.csv", "r", encoding="utf_8_sig").readlines()
lines = [line.strip() for line in lines]

# 获取键值
keys = lines[0].split(',')

line_num = 1
total_lines = len(lines)

parsed_datas = []
while line_num < total_lines:
        values = lines[line_num].split(",")
        parsed_datas.append(dict(zip(keys, values)))

        line_num = line_num + 1

json_str = json.dumps(parsed_datas, ensure_ascii=False, indent=4)

# write to the file
f = open("D:\\project\\items.json", "w", encoding="utf-8")
f.write(json_str)
f.close()