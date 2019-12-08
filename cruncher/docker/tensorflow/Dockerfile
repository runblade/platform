FROM "ubuntu:latest"

RUN apt-get update
RUN apt-get upgrade -y
RUN apt-get install -y python3
RUN apt-get install -y python3-pip
RUN apt-get install -y git protobuf-compiler python-pil python-lxml

RUN python3 -m pip install --upgrade pip
RUN python3 -m pip install tensorflow
RUN python3 -m pip install jupyter
RUN python3 -m pip install matplotlib
RUN python3 -m pip install cython
RUN python3 -m pip install pathlib
RUN python3 -m pip install pycocotools

RUN mkdir -p /tensor
RUN mkdir -p /tensor/tensorflow/models
RUN git clone https://github.com/tensorflow/models.git /tensor/tensorflow/models

WORKDIR /tensor/tensorflow/models/research

RUN protoc object_detection/protos/*.proto --python_out=.
RUN python3 -m pip install .

RUN export PYTHONPATH=$PYTHONPATH:`pwd`:`pwd`/slim
RUN jupyter notebook --generate-config --allow-root
RUN echo "c.NotebookApp.password = u'sha1:6a3f528eec40:6e896b6e4828f525a6e20e5411cd1c8075d68619'" >> /root/.jupyter/jupyter_notebook_config.py

EXPOSE 8888

CMD ["jupyter", "notebook", "--allow-root", "--notebook-dir=/tensor/tensorflow/models/research/object_detection", "--ip=0.0.0.0", "--port=8888", "--no-browser"]