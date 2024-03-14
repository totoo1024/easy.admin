# 使用Node.js 基础镜像
FROM node:18-alpine

RUN mkdir -p /app
WORKDIR /app
COPY . .

#设置镜像源
RUN yarn config set registry https://registry.npmmirror.com/
RUN yarn install && yarn run build
# node 运行端口
ENV PORT=5200
# 容器端口
EXPOSE 5200

CMD ["node","./.output/server/index.mjs"]
