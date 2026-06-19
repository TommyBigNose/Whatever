import json

def print_hi(name):
    print(f'Hi, {name}')

test_list:list[str] = ["test1", "test2", "test3"]
test_dict:dict = {"test1":1, "test2":2, "test3":3}
test_json =  '{ "name":"John", "age":30, "city":"New York"}'


if __name__ == '__main__':
    print_hi('PyCharm')
    print(f"{test_list=}")
    print(f"{test_dict=}")
    print(f"{json.dumps(test_dict)=}")
    print(f"{test_json=}")
    print(f"{json.loads(test_json)=}")