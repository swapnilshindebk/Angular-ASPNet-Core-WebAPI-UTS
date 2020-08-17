
FROM nginx:alpine
LABEL author="Swapnil Shinde"
# COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf
COPY ./dist/Users-Presentation /usr/share/nginx/html
EXPOSE 80 443
ENTRYPOINT [ "nginx","-g","daemon off;" ]

# 1. Build the project using "ng build"

# 2. Build the docker image
# docker build -t nginx-angular -f nginx.dockerfile .

# 3. Run the docker container
# Mac: docker run -p 8080:80 -v $(pwd)/dist:/usr/share/nginx/html nginx-angular
# Windows PowerShell: docker run -p 8080:80 -v ${PWD}/dist:/usr/share/nginx/html nginx-angular
# Windows Command-Line: docker run -p 8080:80 -v %cd%/dist:/usr/share/nginx/html nginx-angular
# Git Bash on Windows: docker run -p 8080:80 -v /$(pwd)/dist:/usr/share/nginx/html nginx-angular