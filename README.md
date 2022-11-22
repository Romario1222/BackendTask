# BackendTask
���������� � ������(Linux server):
-----------
1. � ������ ������� ��� ������������ ������� ��� ����������� docker, ����������� �� ��������� ��������� �����:
```
https://docs.docker.com/desktop/install/linux-install/\
```
2. ����� ����� ������� ������ � ��������� ���� ����������, � ������� �������:
```
git clone https://github.com/Romario1222/BackendTask
```
3. ����� ��������� � ���������� � ��������� BackendTask, ����� ���� ����������� �������:
```
docker compose up --build
```
4. ������ ��������.

������ � ���������:
-----------
0. ��� ������������ �� ������ ������ �������� ���������, � ������ ������ ���������, ����� ������� ����� ��������� ����� ������.
1. ��� ��������� ������������ ����� id � GET ������� /getUser � ���� json ���� ��������� id (id:(���� ������������(�����))), � �������� ������ ����� ������� ��������� � json ValidatedUserDto. � ������ ������������� ������, ��� ��������� ������������ � ���� ������, ����� ������� ����� ��������� ����� ������.
2. ��� ��������� ������������ ����� ��� ������������ � GET ������� /getUser � ���� json ���� ��������� username (username:(��� ������������(������))),� �������� ������ ����� ������� ��������� � json ValidatedUserDto. � ����� ������������� ������ ��� ��������� ������������ � ���� ������, ����� ������� ����� ��������� ����� ������.
3. ��� �������� ������������ ����� � PUT ������� /createUser ��������� username � password � ���� json, � ������ ������ ��� �������� ������������ ����� ������� ����� ��������� ����� ������, ���� ������������ ��� �������� ������� ����� ������� ����� ��������� User Added!
4. ��� �������� ������������ ����� � DELETE ������� /deleteUser ��������� id ������������ � ���� json, � ������ ������ ��� �������� ������������
����� ������� ����� ��������� ����� ������, ���� ������������ ��� ����� ����� ������� ����� ��������� Deleted user!
5. ��� ��������� ������������ ����� � POST ������� /updateUser ��������� id, username, password ������������ � ���� json, � ������ ������ ����� ������� ����� ��������� ����� ������, ����� � �������� ������ ����� ������� ��������� � json ValidatedUserDto.

������ � ����� ������:
-----------
1. ������ � ����� ������ ������������ ����� UserDatabaseRepository.
1.1 ��� �������� ������� ������� ������������ ����� IsTableExist().
1.2 ��� �������� ������� � ������ � ���������� ������������ ����� ConfigureDb().
2. ��� ������ ����� ������ � ���� ������ ������������ ����� CreateUser, ����������� �� ���� ��������� ������ ValidatedUserDto,����� �������� ������ � ���������� ValidatedUserDto, � ������ ���� ��������� ��������, ����������
� ���� ������ ������ ������������.� ������ ������ ������ � ���� ������, � ������� ����� ������� ����� ������.
3. ��� ���������� ������ � ������ � ���� ������ ������������ ����� UpdateUser, ����������� �� ���� ��������� ������ ValidatedUserDto, ����� �������� ������ � ���������� ValidatedUserDto, � ������ ���� ��������� ��������, �������� ������ ������������ � �������������� Id. ��� ���������� �������� ���� username,password,updated_at. � ������ ������ ���������� � ���� ������, � ������� ����� ������� ����� ������.
4. ��� �������� �� ������ �� ���� ������ ������������ ����� DeleteUser, ����������� �� ���� ��������� ������ ValidatedUserDto, ����� �������� ������ � ���������� ValidatedUserDto, � ������ ���� ��������� ��������, ������� ������������ � �������������� Id. � ������ ������ �������� ������ � ���� ������, � ������� ����� ������� ����� ������.
5. ��� ��������� ������ � ������������ ������������ ������ GetUserByName, GetUserById, ������ ��������� �� ���� ��� ������������, � ������ id ������������.����� ����� �� ���� ������ ���������� ������������ � ��������������� ������ ������������/id. ����� ���������� ������ ValidatedUserDto.� ������ ������ ��������� ������ � ������� ����� �������� ������, � ����� ������ null.
