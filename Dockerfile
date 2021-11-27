FROM prestashop/prestashop:1.7.7.8
COPY webshop/ ./
RUN a2enmod ssl