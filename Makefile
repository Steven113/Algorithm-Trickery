
gadd:
	git add *.cpp
	git add *.h
	git add Makefile

PushToRepo:
	git push -u origin master

PullMasterFromRepo:
	git pull https://github.com/Steven113/Algorithm-Trickery.git master