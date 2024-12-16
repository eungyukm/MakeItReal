from django.db import models
from django.utils.timezone import now


class User(models.Model):
    username = models.CharField(max_length=150)
    email = models.EmailField(unique=True)
    password = models.CharField(max_length=128)
    date_joined = models.DateTimeField(default=now)
    is_active = models.BooleanField()
