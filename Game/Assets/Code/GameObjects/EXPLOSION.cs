using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EXPLOSION
{
    public static void explosionCreate(Object ObjRef, Vector3 position, Color startColor)
    {
        GameObject explosionObject = (GameObject)Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;
        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Stop();
        ParticleSystem.MainModule main = explosion.main;
        main.simulationSpeed = Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
        main.startSize = Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);
        main.startLifetime = Random.Range(CONSTANTS.BULLET_END_LIFE_MIN, CONSTANTS.BULLET_END_LIFE_MAX);
        main.duration = Random.Range(CONSTANTS.BULLET_DURATION_MIN, CONSTANTS.BULLET_DURATION_MAX);
        main.startColor = startColor;
        explosion.Play();
    }
    public static void explosionCreateRotate(Object ObjRef, Vector3 position, Color startColor)
    {
        GameObject explosionObject = (GameObject)Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;
        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Stop();
        ParticleSystem.MainModule main = explosion.main;
        explosion.transform.rotation = Random.rotation;
        main.simulationSpeed = Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
        main.startSize = Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);
        main.startLifetime = Random.Range(CONSTANTS.BULLET_END_LIFE_MIN, CONSTANTS.BULLET_END_LIFE_MAX);
        main.duration = Random.Range(CONSTANTS.BULLET_DURATION_MIN, CONSTANTS.BULLET_DURATION_MAX);
        main.startColor = startColor;
        explosion.Play();
    }
    public static void explosionCreateConsant(Object ObjRef, Vector3 position, Color startColor)
    {
        GameObject explosionObject = (GameObject)Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;
        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Stop();
        ParticleSystem.MainModule main = explosion.main;
        main.simulationSpeed = Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
        main.startSize = Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);
        main.startColor = startColor;
        explosion.Play();
    }
}

/*
        GameObject explosionObject = (GameObject)Object.Instantiate(ObjRef);
        explosionObject.transform.position = position;
        ParticleSystem explosion = explosionObject.GetComponent<ParticleSystem>();
        explosion.Stop();
        ParticleSystem.MainModule main = explosion.main;
        explosion.transform.rotation = Random.rotation;
        main.simulationSpeed = Random.Range(CONSTANTS.BULLET_SIM_SPEED_MIN, CONSTANTS.BULLET_SIM_SPEED_MAX);
        main.startSize = Random.Range(CONSTANTS.BULLET_SIM_START_SIZE_MIN, CONSTANTS.BULLET_SIM_START_SIZE_MAX);
        //explosion.particleCount = Random.Range(CONSTANTS.BULLET_PARTICLE_COUNT_MIN , CONSTANTS.BULLET_PARTICLE_COUNT_MAX);
        main.startLifetime = Random.Range(CONSTANTS.BULLET_END_LIFE_MIN, CONSTANTS.BULLET_END_LIFE_MAX);
        main.duration = Random.Range(CONSTANTS.BULLET_DURATION_MIN, CONSTANTS.BULLET_DURATION_MAX);
        main.startColor = startColor;
        explosion.Play();
*/


