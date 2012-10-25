package atbmtt;

import java.io.FileOutputStream;
import java.security.*;
import java.security.interfaces.*;
import java.security.interfaces.RSAPublicKey;

public class Taokhoa {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			KeyPairGenerator gen = KeyPairGenerator.getInstance("RSA");
			KeyPair key = gen.generateKeyPair();

			RSAPublicKey kp = (RSAPublicKey) key.getPublic();
			RSAPrivateKey ks = (RSAPrivateKey) key.getPrivate();

			FileOutputStream fos = new FileOutputStream("c:\\kp.txt");
			fos.write(kp.getEncoded());
			fos.close();

			fos = new FileOutputStream("c:\\ks.txt");
			fos.write(ks.getEncoded());
			fos.close();

			/*
			 * BigInteger exponent = kp.getPublicExponent(); BigInteger modulus
			 * = kp.getModulus(); FileWriter wr = new FileWriter("d:\\kp.txt");
			 * wr.write(exponent.toString()+"\n");
			 * wr.write(modulus.toString()+"\n"); wr.close();
			 */

			/*
			 * wr = new FileWriter("d:\\ks.txt"); exponent =
			 * ks.getPrivateExponent(); modulus = ks.getModulus();
			 * wr.write(exponent.toString()+"\n");
			 * wr.write(modulus.toString()+"\n"); wr.close();
			 */

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
