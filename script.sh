#!/bin/bash

DATABASE_NAME="BE_180043"
DATABASE_USER="BE_180043"
DATABASE_PASSWORD="password"
DATABASE_ROOT_PASSWORD="student"
SHOP_URL="localhost:18125"
SHOP_SSL_URL="localhost"18126"

mysql -p$DATABASE_ROOT_PASSWORD -e "DROP DATABASE IF EXISTS ${DATABASE_NAME};"
mysql -p$DATABASE_ROOT_PASSWORD -e "CREATE DATABASE ${DATABASE_NAME};"
mysql -p$DATABASE_ROOT_PASSWORD -e "USE ${DATABASE_NAME};"
mysql -p$DATABASE_ROOT_PASSWORD -e "CREATE USER IF NOT EXISTS ${DATABASE_USER}@'%' IDENTIFIED BY '${DATABASE_PASSWORD}';"
mysql -p$DATABASE_ROOT_PASSWORD -e "GRANT ALL PRIVILEGES ON ${DATABASE_NAME}.* TO '${DATABASE_USER}'@'%';"
mysql -p$DATABASE_ROOT_PASSWORD -e "FLUSH PRIVILEGES;"
mysql -u $DATABASE_USER -p$DATABASE_PASSWORD $DATABASE_NAME < /tmp/${DATABASE_NAME}.sql
mysql -u $DATABASE_USER -p$DATABASE_PASSWORD $DATABASE_NAME -e "UPDATE ps_shop_url SET domain='${SHOP_URL}', domain_ssl='${SHOP_SSL_URL}' WHERE id_shop_url=1;"