package nl.videodock.mediasession;

import android.media.MediaRouter;

import androidx.media.VolumeProviderCompat;

public class MediaSessionVolume extends VolumeProviderCompat {

    OnMediaSessionEventListener mListener;

    public void setMediaSessionEventListener(OnMediaSessionEventListener listener) {
        mListener = listener;
    }

    public MediaSessionVolume() {
        super(VolumeProviderCompat.VOLUME_CONTROL_ABSOLUTE, 100, 50);
    }

    @Override
    public void onAdjustVolume(int delta) {
        if (mListener != null) {
            if (delta > 0) {
                mListener.onVolumeUp();
            }
            else if (delta < 0) {
                mListener.onVolumeDown();
            }
        }
    }
}
